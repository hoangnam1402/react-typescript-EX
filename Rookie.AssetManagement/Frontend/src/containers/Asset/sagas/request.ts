import { AxiosResponse } from "axios";
import qs from 'qs';
import RequestService from 'src/services/request';
import EndPoints from 'src/constants/endpoints';
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import IAsset from "src/interfaces/Asset/IAsset";
import IAssetForm from "src/interfaces/Asset/IAssetForm";


export function getAssetsRequest(query: IQueryAssetModel): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.getAsset, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function getAssetCategoryRequest(): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.getAssetCategory);
}

export function createAssetRequest(assetForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.post(EndPoints.getAsset, assetForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function deleteAssetRequest(assetId: number): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.delete(EndPoints.deleteAssetId(assetId ?? -1))
}
export function putAssetsRequest(userForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.put(EndPoints.getAssetId(userForm.id ?? -1), userForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}