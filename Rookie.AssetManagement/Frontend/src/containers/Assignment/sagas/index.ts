import { takeLatest } from 'redux-saga/effects';

import { createAssignments, deleteAssignments, getAssignments, updateAssignment } from '../reducer';
import { handleCreateAssignment, handleDeleteAssignment, handleGetAssignment, handleUpdateAssignment} from './handles';

export default function* assignmentSagas() {
    yield takeLatest(getAssignments.type, handleGetAssignment);
    yield takeLatest(createAssignments.type, handleCreateAssignment);
    yield takeLatest(deleteAssignments.type, handleDeleteAssignment);
    yield takeLatest(updateAssignment.type, handleUpdateAssignment);
}
