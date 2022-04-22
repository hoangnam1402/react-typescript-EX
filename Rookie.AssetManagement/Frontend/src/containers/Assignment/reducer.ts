import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "src/constants/status";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IError from "src/interfaces/IError";
import IPagedModel from "src/interfaces/IPagedModel";
import IQueryAssignmentModel  from "src/interfaces/Assignment/IQueryAssignment";
import IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";

import {
  getLocalStorage,
  removeLocalStorage,
  setLocalStorage,
} from "src/utils/localStorage";
import { AssignmentState } from "src/constants/States";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";

export type CreateAction = {
  handleResult: Function,
  formValues: IAssignmentForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IAssignment,
}

type AssignmentState = {
	loading: boolean;
	assignmentResult?: IAssignment;
	status?: number;
	error?: IError;
	assignments: IPagedModel<IAssignment> | null;
	newAssignment?: IAssignment;
	deleteAssignment?: IAssignment;
};

const token = getLocalStorage("token");


const initialState: AssignmentState = {
  loading: false,
  assignments: null,
  newAssignment: undefined,
};

const assignmentSlice = createSlice({
	name: "assignment",
	initialState,
	reducers: {

		getAssignments: (
			state,
			action: PayloadAction<IQueryAssignmentModel>,
		): AssignmentState => {
			return {
				...state,
				loading: true,
			};
		},

		setAssignments: (
			state,
			action: PayloadAction<IPagedModel<IAssignment>>,
		): AssignmentState => {
			const assignments = action.payload;

			if (state.newAssignment) {
				const str = assignments.items.findIndex(
					(x) => x.id === state.newAssignment?.id,
				);
				if (str) {
					assignments.items.splice(str, 1);
				}
				assignments.items.unshift(state.newAssignment);
				console.log(state.newAssignment);
			}

			if(state.assignmentResult){
				assignments.items.unshift(state.assignmentResult);
			}

			return {
				...state,
				assignments,
				newAssignment: undefined,
				assignmentResult: undefined,
				loading: false,
			};

		},
		setStatus: (
			state: AssignmentState,
			action: PayloadAction<SetStatusType>,
		) => {
			const { status, error } = action.payload;

			return {
				...state,
				status,
				error,
				loading: false,
			};
		},

		createAssignments: (
			state: AssignmentState,
			action: PayloadAction<CreateAction>,
		) => {
			return {
				...state,
				loading: true,
			};
		},

		setNewAssignment: (
			state: AssignmentState,
			action: PayloadAction<IAssignment | undefined>,
		) => {
			const newAssignment = action.payload;

			return {
				...state,
				newAssignment,
				loading: false,
			};
		},

		updateAssignment: (
			state,
			action: PayloadAction<CreateAction>,
		): AssignmentState => {
			return {
				...state,
				loading: true,
			};
		},
		setAssignment: (
			state,
			action: PayloadAction<IAssignment>,
		): AssignmentState => {
			const assignmentResult = action.payload;

			return {
				...state,
				assignmentResult,
				loading: false,
			};
		},
		
		setAssignmentEdited: (
			state,
			action: PayloadAction<IAssignment>,
		): AssignmentState => {
			const assignmentResult = action.payload;

			return {
				...state,
				assignmentResult,
				loading: false,
			};
		},
		deleteAssignments: (
			state,
			action: PayloadAction<CreateAction>,
		): AssignmentState => {
			return {
				...state,
				loading: true,
			};
		},

		setDeleteAssignment: (
			state,
			action: PayloadAction<IAssignment>,
		): AssignmentState => {
			const deleteAssignment = action.payload;

			return {
				...state,
				deleteAssignment,
			};
		},
	},
});

export const {
	setStatus,
	getAssignments,
	setAssignments,
	createAssignments,
	setNewAssignment,
	deleteAssignments,
	setDeleteAssignment,
	updateAssignment,
	setAssignmentEdited,
	setAssignment,
} = assignmentSlice.actions;

export default assignmentSlice.reducer;
