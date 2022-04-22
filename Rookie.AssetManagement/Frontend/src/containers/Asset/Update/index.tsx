import React, { useEffect, useState } from 'react'
import { Redirect, useParams } from 'react-router';

import { HOME, NOTFOUND } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import AssetForm from '../AssetForm';
import IAssetForm from 'src/interfaces/Asset/IAssetForm';
import Roles from "src/constants/roles";


const UpdateAssetContainer = () => {

    const { isAuth, account } = useAppSelector((state) => state.authReducer);
    const dispatch = useAppDispatch();
    const role = account?.role;
  
    const { assets } = useAppSelector(state => state.assetReducer);
    
    const [asset, setAsset] = useState(undefined as IAssetForm | undefined);
  
    const { id } = useParams<{ id: string }>();
    
    const existAsset = assets?.items.find(item => item.id === Number(id));
  
    useEffect(() => {
  
      if (existAsset) {
          setAsset({
              id: existAsset.id,
              name: existAsset.name,
              specification: existAsset.specification,
              state: existAsset.state,
              installDate: existAsset.installDate,
              categoryID: existAsset.categoryID
        });
      }
    }, [existAsset]);
  
    return (
      <>
        {role == Roles.Admin && (
          <div className='ml-5'>
            <div className='primaryColor text-title intro-x'>
              Update Asset {existAsset?.name}
            </div>
      
            <div className='row'>
          {
            asset && (<AssetForm
              initialAssetForm={asset}
    
            />)
          }
        </div>
      
          </div>
        )}
        {role == Roles.Staff && (
          <Redirect to={HOME} />
        )}
      </>
    );
  };
  
  export default UpdateAssetContainer;