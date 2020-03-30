//Models for react

export interface FoodModel {
    Id: number;
    Name: string;
    Description: string;
    Picture: string;
    Price: number;
    Quantity: number;

}

//state class to hold info as front end application runs
export interface IAppState {

    items: FoodModel[];
    myOrder: FoodModel[];
    showPopup: boolean; 
    userId: number;
    orderPlaced: boolean;
}
