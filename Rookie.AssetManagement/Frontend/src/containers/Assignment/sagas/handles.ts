import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "src/constants/status";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignment";
import IError from "src/interfaces/IError";
import IAssignment from "src/interfaces/Assignment/IAssignmentForm";


import { setStatus, setAssignments, CreateAction, setNewAssignment, DeleteAction, setDeleteAssignment, setAssignment, setAssignmentEdited } from "../reducer";


import {  deleteAssignmentRequest, getAssignmentRequest, postCreateAssignment,
	putAssignmentsRequest, } from './request';


export function* handleGetAssignment(action: PayloadAction<IQueryAssignmentModel>) {
    const query = action.payload;
    try {
        //console.log('handleGetAsset');
        const { data } = yield call(getAssignmentRequest, query);
        
        yield put(setAssignments(data));

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleCreateAssignment(action: PayloadAction<CreateAction>)
{
    const { handleResult, formValues} = action.payload;

    try{console.log("handleCreateAssignment");
		console.log(formValues);
        const { data } =  yield call(postCreateAssignment, formValues);

        handleResult(true);

        yield put(setNewAssignment(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

         yield put(setStatus({
             status:Status.Failed,
             error:errorModel
         }));
    }
}

export function* handleDeleteAssignment(action: PayloadAction<DeleteAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(deleteAssignmentRequest, formValues.id);
        if(data) {
            handleResult(true);
        }
        yield put(setStatus({
            status: Status.Success,
        }));
        yield put(setDeleteAssignment(formValues));

        //window.location.reload();

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}
export function* handleUpdateAssignment(action: PayloadAction<CreateAction>) {
	const { handleResult, formValues } = action.payload;

	try {
		const { data } = yield call(putAssignmentsRequest, formValues);
        console.log(formValues);
		handleResult(true, data);

		yield put(setAssignment(data));

		if (formValues.id) {
			yield put(setAssignmentEdited(data));
		}
	} catch (error: any) {
		const errorModel = error.response.data as IError;

		handleResult(false, errorModel.message);
	}
}
