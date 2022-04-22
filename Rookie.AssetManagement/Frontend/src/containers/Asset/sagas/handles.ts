import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "src/constants/status";
import IAsset from "src/interfaces/Asset/IAsset";
import IAssetCategory from "src/interfaces/Asset/IAssetCategory";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import IError from "src/interfaces/IError";
import ISubmitAction from "src/interfaces/ISubmitActions";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import { setStatus, setAssets, setAssetCategories, CreateAction, setDeleteAsset, setAsset, DeleteAction, setAssetEdited } from "../reducer";
import { createAssetRequest, getAssetCategoryRequest, getAssetsRequest, deleteAssetRequest, putAssetsRequest } from './request';

export function* handleGetAssets(action: PayloadAction<IQueryAssetModel>) {
    const query = action.payload;
    try {
        //console.log('handleGetAsset');
        const { data } = yield call(getAssetsRequest, query);
        
        yield put(setAssets(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetAssetCategory() {
    try {
        const { data } = yield call(getAssetCategoryRequest);
        yield put(setAssetCategories(data))
        

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
    }
}

export function* handleCreateAsset(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        console.log('handleCreateAsset');
        console.log(formValues);
        
        const { data } = yield call(createAssetRequest, formValues);
        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setAsset(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDeleteAsset(action: PayloadAction<DeleteAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(deleteAssetRequest, formValues.id);
        if(data) {
            handleResult(true, formValues.name);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDeleteAsset(formValues));

        //window.location.reload();

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}
export function* handleUpdateAsset(action: PayloadAction<CreateAction>) {
    const { handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(putAssetsRequest, formValues);

        handleResult(true, data);

        yield put(setAsset(data));

        if(formValues.id){
            yield put(setAssetEdited(data));
        }
        
    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}
