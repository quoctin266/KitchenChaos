using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class StoveCounter : BaseCounter 
{
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;

    public class OnStateChangedEventArgs : EventArgs {
        public State state;
    }

    public enum State {
        Idle,
        Frying,
        Fried,
        Burned
    }

    [SerializeField] private List<FryingRecipeSO> fryingRecipes;

    private FryingRecipeSO fryingRecipe;

    private float fryingTimer;

    private State state;

    private void Start() {
        state = State.Idle;
    }

    void Update() {
        var kitchenObject = GetKitchenObject();
        if (kitchenObject != null) {
            switch (state) {
                case State.Idle:
                    break;
                case State.Frying:
                    if (fryingRecipe != null) {
                        fryingTimer += Time.deltaTime;

                        if (fryingTimer >= fryingRecipe.fryingTimerMax) {
                            kitchenObject.DestroySelf();

                            KitchenObject.SpawnKitchenObject(fryingRecipe.output, this);

                            fryingRecipe = fryingRecipes.FirstOrDefault(x => x.input == GetKitchenObject().GetKitchenObjectSO());

                            // Frying a cooked meat patty will result in a burned meat patty, so if the fryingRecipe is null, we set the state to Burned directly
                            if (fryingRecipe == null) {
                                state = State.Burned;
                            }
                            else {
                                state = State.Fried;
                            }

                            fryingTimer = 0f;

                            OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });
                        }
                    }
                    break;
                case State.Fried:
                    if (fryingRecipe != null) {
                        fryingTimer += Time.deltaTime;

                        if (fryingTimer >= fryingRecipe.fryingTimerMax) {
                            kitchenObject.DestroySelf();

                            KitchenObject.SpawnKitchenObject(fryingRecipe.output, this);

                            state = State.Burned;

                            fryingTimer = 0f;

                            OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });
                        }
                    }
                    break;
                case State.Burned:
                    break;
                default:
                    break;
            }
        }
    }

    public override void Interact(Player player) {
        // Player drop object on counter
        if (player.GetKitchenObject() != null && GetKitchenObject() == null) {
            var kitchenObject = player.GetKitchenObject();
            var recipe = fryingRecipes.FirstOrDefault(x => x.input == kitchenObject.GetKitchenObjectSO());

            // If the object can be fried, place it on the counter
            if (recipe != null) {
                fryingRecipe = recipe;

                kitchenObject.SetKitchenObjectParent(this);

                fryingTimer = 0f;

                state = State.Frying;

                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });
            }
        }
        // Player pick up object from counter
        else if (player.GetKitchenObject() == null && GetKitchenObject() != null) {
            GetKitchenObject().SetKitchenObjectParent(player);

            state = State.Idle;

            OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });
        }
    }

    public override void InteractAlternate(Player player) {
        Debug.Log("StoveCounter InteractAlternate");
    }
}
