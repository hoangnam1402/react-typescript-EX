import { takeLatest } from 'redux-saga/effects';

import { createUserByAdmin, getUsers, updateUser } from '../reducer';
import { handleCreateUserByAdmin,handleGetUsers, handleUpdateUser } from './handles';

export default function* userSagas() {
    yield takeLatest(createUserByAdmin.type, handleCreateUserByAdmin);
    yield takeLatest(getUsers.type, handleGetUsers);
    yield takeLatest(updateUser.type, handleUpdateUser);
}
