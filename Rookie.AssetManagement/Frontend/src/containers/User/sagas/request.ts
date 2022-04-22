import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from 'src/services/request';
import EndPoints from 'src/constants/endpoints';
import ILoginModel from "src/interfaces/ILoginModel";
import IAccount from "src/interfaces/IAccount";
import IChangePassword from "src/interfaces/IChangePassword";
import IUserForm from "src/interfaces/User/IUserForm";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import IUser from "src/interfaces/User/IUser";


export function postCreateUser(createUserByAdmin: IUserForm): Promise<AxiosResponse<IUserForm>> {
    return RequestService.axios.post(EndPoints.createUser, createUserByAdmin)
}

export function getUsersRequest(query: IQueryUserModel): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.get(EndPoints.getUser, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function putUsersRequest(userForm: IUserForm): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.put(EndPoints.getUserId(userForm.userId ?? -1), userForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}