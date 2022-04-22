import React, { Fragment, lazy, useEffect, useState } from "react";
import Roles from "src/constants/roles";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Redirect, Route, Switch } from "react-router-dom";
import { Link, useHistory } from 'react-router-dom';
import { HOME } from '../../constants/pages'
import { MANAGE_USER, CREATE_USER, EDIT_USER } from 'src/constants/pages';
import PrivateRoute from "src/routes/PrivateRoute";

const NotFound = lazy(() => import("../NotFound"));
const CreateUser = lazy(() => import("./Create"));
const ListUser = lazy(() => import("./List"));
const UpdateUser = lazy(() => import("./Update"))
const User = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;
  //console.log(role);

  return (
    <>
      {role == Roles.Admin && (
        <Fragment>
        <Route exact path={CREATE_USER}>
          <CreateUser />
        </Route>
        <Route exact path={MANAGE_USER}>
          <ListUser />
        </Route>
        <Route exact path={EDIT_USER}>
          <UpdateUser />
        </Route>
        </Fragment>
      )}
      {role == Roles.Staff && (
        <Redirect to={HOME} />
      )}
    </>
  );
}

export default User;
