import { takeLatest } from 'redux-saga/effects';

import { getAssets, getAssetCategories, deleteAssets, createAsset, updateAsset } from '../reducer';
import { handleGetAssets, handleGetAssetCategory, handleDeleteAsset, handleCreateAsset, handleUpdateAsset } from './handles';

export default function* assetSagas() {
    yield takeLatest(deleteAssets.type, handleDeleteAsset);
    yield takeLatest(getAssets.type, handleGetAssets);
    yield takeLatest(getAssetCategories.type,handleGetAssetCategory);
    yield takeLatest(createAsset.type,handleCreateAsset);
    yield takeLatest(updateAsset.type,handleUpdateAsset);
}
