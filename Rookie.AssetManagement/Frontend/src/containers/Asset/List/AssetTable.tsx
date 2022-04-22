import React, { ReactElement, useEffect, useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import { NotificationManager } from 'react-notifications';

import { EDIT_ASSET_ID } from "src/constants/pages";
import IAsset from "src/interfaces/Asset/IAsset";
import { AssetState } from "src/constants/States";
import Info from "../Info";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { deleteAssets, setNewAsset } from "../reducer";
import DeleteModal from "src/components/DeleteModal";

const columns: IColumnOption[] = [
  { columnName: "Asset Code", columnValue: "code" },
  { columnName: "Asset Name", columnValue: "name" },
  { columnName: "Category", columnValue: "category" },
  { columnName: "State", columnValue: "state" },
];

type Props = {
  assets: IPagedModel<IAsset> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
  deleteAsset?: IAsset
};

const AssetTable: React.FC<Props> = ({
  assets,
  handlePage,
  handleSort,
  sortState,
  fetchData,
  deleteAsset,
}) => {
  const dispatch = useAppDispatch();

  const [showConfirmDelete, setShowConfirmDelete] = useState(false);
  const [assetDetail, setAssetDetail] = useState(null as IAsset | null);

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      NotificationManager.success(
          `Delete Successful Asset ${message}`,
          2000,
      );
      deleteAsset = undefined;
    } else {
      NotificationManager.error(message, 'Delete failed', 2000);
    }
  };

  const handleCancleDelete = () => {
      setShowConfirmDelete(false);
  }
  const [showDetail, setShowDetail] = useState(false);
  const handleShowInfo = (assetCode: string) => {
    const asset = assets?.items.find((item) => item.code == assetCode);
    console.log(asset);
    if (asset) {
      setAssetDetail(asset);
      setShowDetail(true);
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  }
  
  const history = useHistory();
  const handleEdit = (id: number) => {
      history.push(EDIT_ASSET_ID(id));
  };

  const handleDelete = (code: string) => {
    const asset = assets?.items.find((item) => item.code == code);

    if(asset)
    {
      setShowConfirmDelete(true)
      setAssetDetail(asset)
    }
  }

  const handleAcceptDelete = () => {
    if(assetDetail)
    {
      setShowConfirmDelete(false);
      dispatch(deleteAssets({ handleResult, formValues: assetDetail }));
    }
  }
  
  useEffect( () => () => {dispatch(setNewAsset(undefined))}, [] );

  const {status , newAsset} = useAppSelector((state) => state.assetReducer);
  function NewCreatedContent(): ReactElement{
    return (
      <tr
        // key={99}
        // className=""
        // onClick={() => handleShowInfo(newAsset!.code)}
      >
        <td className="py-1">{newAsset!.code}</td>
        <td className="py-1">{newAsset!.name}</td>
        <td className="py-1">{newAsset!.category.name}</td>
        <td className="py-1">{AssetState[newAsset!.state]}</td>

        <td className="d-flex py-1">
          <ButtonIcon>
            <PencilFill className="text-black" />
          </ButtonIcon>
          <ButtonIcon>
            <XCircle className="text-danger mx-2" />
          </ButtonIcon>
        </td>
      </tr>
    );
  }

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: assets?.currentPage,
          totalPage: assets?.totalPages,
          handleChange: handlePage,
        }}
      
      >
         {newAsset && NewCreatedContent()}
        {assets?.items.map((data, index) => (
          <tr 
            key={index} 
            className=""
            onClick={() => handleShowInfo(data.code)}
          >
            <td className="py-1">{data.code}</td>
            <td className="py-1">{data.name} </td>
            <td className="py-1">{data.category.name}</td>
            <td className="py-1">{AssetState[data.state]}</td>

            <td className="d-flex py-1">
              <ButtonIcon onClick={() => handleEdit(data.id)} disable={data.state==3?true:false}>
                <PencilFill className="text-black" />
              </ButtonIcon>
              <ButtonIcon disable={data.state==3?true:false} onClick={() => handleDelete(data.code)}>
                <XCircle className="text-danger mx-2" />
              </ButtonIcon>
            </td>
          </tr>
        ))}
      </Table>
      <DeleteModal
        title="Are you sure"
        isShow={showConfirmDelete}
        onHide={handleCancleDelete}
      >
        <div>
          <div className="text-center">Do you want to delete this Asset?</div>
          <div className="text-center mt-3">
            <button
              className="btn btn-danger mr-3"
              onClick={handleAcceptDelete}
              type="button"
            >
              Delete
            </button>
            <button
              className="btn btn-outline-secondary"
              onClick={handleCancleDelete}
              type="button"
            >
              Cancel
            </button>
          </div>
        </div>
      </DeleteModal>

      {assetDetail && showDetail && (
        <Info asset={assetDetail} handleClose={handleCloseDetail} />
      )}
    </>
  );
};

export default AssetTable;