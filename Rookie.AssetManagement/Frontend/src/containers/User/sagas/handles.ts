import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "src/constants/status";
import IError from "src/interfaces/IError";
import ISubmitAction from "src/interfaces/ISubmitActions";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import IUser from "src/interfaces/User/IUser";
import IUserForm from "src/interfaces/User/IUserForm";
import { setStatus, setUsers, CreateAction, setUser, setNewUser, setUserEdited } from "../reducer";


import {  postCreateUser, getUsersRequest, putUsersRequest } from './request';


export function* handleCreateUserByAdmin(action: PayloadAction<CreateAction>)
{
    const { handleResult, formValues} = action.payload;

    try{
        const { data } =  yield call(postCreateUser, formValues);

        handleResult(true, data.userName);

        yield put(setUser(data));
        
        if(formValues.userId){
            yield put(setNewUser(data));
        }

    } catch (error: any) {
        const errorModel = error.response.data as IError;

         yield put(setStatus({
             status:Status.Failed,
             error:errorModel
         }));
    }
}

export function* handleGetUsers(action: PayloadAction<IQueryUserModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getUsersRequest, query);
        
        yield put(setUsers(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleUpdateUser(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(putUsersRequest, formValues);

        handleResult(true, data);

        yield put(setUser(data));

        if(formValues.userId){
            const userEdited = formValues as IUser
            yield put(setUserEdited(data));
        }
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}
