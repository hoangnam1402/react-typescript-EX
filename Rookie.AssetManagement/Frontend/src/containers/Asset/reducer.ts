import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "src/constants/status";
import IAsset from "src/interfaces/Asset/IAsset";
import IAccount from "src/interfaces/IAccount";
import IError from "src/interfaces/IError";
import IPagedModel from "src/interfaces/IPagedModel";

import IAssetCategory from "src/interfaces/Asset/IAssetCategory"; 
import {
  getLocalStorage,
  removeLocalStorage,
  setLocalStorage,
} from "src/utils/localStorage";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import IAssetForm from "src/interfaces/Asset/IAssetForm";


type AssetState = {
  loading: boolean;
  assetResult?: IAsset;
  status?: number;
  error?: IError;
  assets: IPagedModel<IAsset> | null;
  assetCategories:IAssetCategory[]|null;
  deleteAsset?: IAsset;
  newAsset?:IAsset
};

const token = getLocalStorage("token");

const initialState: AssetState = {
  loading: false,
  assets: null,
  assetCategories:null,
  deleteAsset: undefined,
  newAsset: undefined,
};

export type CreateAction = {
  handleResult: Function,
  formValues: IAssetForm,
}

export type DeleteAction = {
  handleResult: Function,
  formValues: IAsset,
}

const AssetSlice = createSlice({
  name: "Asset",
  initialState,
  reducers: {
    getAssets: (state, action: PayloadAction<IQueryAssetModel>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssets: (state, action: PayloadAction<IPagedModel<IAsset>>): AssetState => {
      const assets = action.payload;
      if(state.assetResult){
          assets.items.unshift(state.assetResult);
      }

      return {
          ...state,
          assets,
          assetResult: undefined,
          loading: false,
      };
    },

    deleteAssets: (state, action: PayloadAction<CreateAction>): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setDeleteAsset: ( state, action: PayloadAction<IAsset>): AssetState => {
      const deleteAsset = action.payload

      return {
        ...state,
        deleteAsset,
      }
    },

    updateAsset: (state, action: PayloadAction<CreateAction>): AssetState => {
      return {
          ...state,
          loading: true,
      }
    },
    setAsset: (state, action: PayloadAction<IAsset>): AssetState => {
      const assetResult = action.payload;

      return {
          ...state,
          assetResult,
          loading: false,
      }
  },
    getAssetCategories: (state): AssetState => {
      return {
        ...state,
        loading: true,
      };
    },

    setAssetCategories: (
      state,
      action: PayloadAction<IAssetCategory[]>
    ): AssetState => {
      const assetCategories = action.payload;
      return {
        ...state,
        assetCategories,
        loading: false,
      };
    },
    
    setStatus: (state: AssetState, action: PayloadAction<SetStatusType>) => {
      const { status, error } = action.payload;

      return {
        ...state,
        status,
        error,
        loading: false,
      };
    },
    setAssetEdited: (state, action: PayloadAction<IAsset>): AssetState => {
      const assetResult = action.payload;
                      
      return {
          ...state,
          assetResult,
          loading: false,
      }
  },
    createAsset: (state, action: PayloadAction<CreateAction>): AssetState => {
      const newAsset = action.payload;
      
      return {
          ...state,
          loading: true,
      }
    },
    setNewAsset: (state: AssetState, action: PayloadAction<IAsset|undefined>) =>
    {
        const newAsset= action.payload;

        return {
            ...state,
            newAsset,
            loading: false,
        }
    },
  },
});

export const { setStatus, getAssets, setAssets, setAssetCategories, getAssetCategories, setDeleteAsset, deleteAssets, createAsset, setAsset, updateAsset, setAssetEdited, setNewAsset
} = AssetSlice.actions;

export default AssetSlice.reducer;
