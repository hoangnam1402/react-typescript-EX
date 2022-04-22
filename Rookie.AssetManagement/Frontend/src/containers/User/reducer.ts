import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "src/constants/status";
import IAccount from "src/interfaces/IAccount";
import IError from "src/interfaces/IError";
import IPagedModel from "src/interfaces/IPagedModel";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import IUser from "src/interfaces/User/IUser";
import IUserForm from "src/interfaces/User/IUserForm";
import { getLocalStorage, removeLocalStorage, setLocalStorage } from "src/utils/localStorage";

type UserState = {
    loading: boolean;
    userResult?: IUser;
    status?: number;
    error?: IError;
    users: IPagedModel<IUser> | null;
    newUser?:IUser
}

export type CreateAction = {
    handleResult: Function,
    formValues: IUserForm,
}

const token = getLocalStorage('token');


const initialState: UserState = {
    loading: false,
    users: null,
    newUser: undefined,
};



const UserSlice = createSlice({
    name: 'User',
    initialState,
    reducers: {
        getUsers: (state, action: PayloadAction<IQueryUserModel>): UserState => {

            return {
                ...state,
                loading: true,
            }
        },

        setUsers: (state, action: PayloadAction<IPagedModel<IUser>>): UserState => {
            const users = action.payload;
            if(state.userResult){
                const str = users.items.findIndex((x) => x.id === state.userResult?.id)
                console.log(str)
                if(str)
                {
                    users.items.splice(str, 1)
                }
                users.items.unshift(state.userResult);
            }

            return {
                ...state,
                users,
                userResult: undefined,
                loading: false,
            }
        },

        createUserByAdmin: (state: UserState, action: PayloadAction<CreateAction>) => {
            return {
                ...state,
                loading: true,
            }
        },

        updateUser: (state, action: PayloadAction<CreateAction>): UserState => {
            return {
                ...state,
                loading: true,
            }
        },

        setUser: (state, action: PayloadAction<IUser>): UserState => {
            const userResult = action.payload;

            return {
                ...state,
                userResult,
                loading: false,
            }
        },

        setUserEdited: (state, action: PayloadAction<IUser>): UserState => {
            const userResult = action.payload;
                            
            return {
                ...state,
                userResult,
                loading: false,
            }
        },
       
        setStatus: (state: UserState, action: PayloadAction<SetStatusType>) =>
        {
            const {status, error} = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },

        setNewUser: (state: UserState, action: PayloadAction<IUser|undefined>) =>
        {
            const newUser= action.payload;

            return {
                ...state,
                newUser,
                loading: false,
            }
        },

        
    }
});

export const {
    setStatus, createUserByAdmin, getUsers, setUsers, updateUser, setUser, setNewUser, setUserEdited
} = UserSlice.actions;

export default UserSlice.reducer;
