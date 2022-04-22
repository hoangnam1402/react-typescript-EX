import React, { useEffect, useState } from 'react'
import { Redirect, useParams } from 'react-router';

import { HOME, NOTFOUND } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IUserForm from 'src/interfaces/User/IUserForm';
import UserForm from '../UserForm';
import Roles from "src/constants/roles";

const UpdateUserContainer = () => {

  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;

  const { users } = useAppSelector(state => state.userReducer);
  
  const [user, setUser] = useState(undefined as IUserForm | undefined);

  const { id } = useParams<{ id: string }>();
  
  const existUser = users?.items.find(item => item.id === Number(id));

  useEffect(() => {

    if (existUser) {
        setUser({
            userId: existUser.id,
            firstName: existUser.firstName,
            lastName: existUser.lastName,
            DOB: existUser.dob,
            gender: existUser.gender,
            joinDate: existUser.joinDate,
            type: existUser.type
      });
    }
  }, [existUser]);

  return (
    <>
      {role == Roles.Admin && (
        <div className='ml-5'>
          <div className='primaryColor text-title intro-x'>
            Update User {existUser?.fullName}
          </div>
    
          <div className='row'>
        {
          user && (<UserForm
            initialUserForm={user}
  
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

export default UpdateUserContainer;
