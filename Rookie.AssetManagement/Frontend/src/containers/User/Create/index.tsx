import React from 'react'
import UserFormContainer from '../UserForm';
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import Roles from "src/constants/roles";
import { Redirect } from "react-router-dom";
import { HOME } from '../../../constants/pages'

const CreateUser = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;

  return (
    <>
      {role == Roles.Admin && (
        <div className='ml-5'>
          <div className='primaryColor text-title intro-x'>
            Create New User
          </div>
    
          <div className='row'>
            <UserFormContainer/>
          </div>
    
        </div>
      )}
      {role == Roles.Staff && (
        <Redirect to={HOME} />
      )}
    </>
  );
}

export default CreateUser