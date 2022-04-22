import React, { Fragment, lazy, useEffect, useState } from "react";
import Roles from "src/constants/roles";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Redirect, Route, Switch } from "react-router-dom";
import { Link, useHistory } from 'react-router-dom';
import { EDIT_ASSET, HOME, MANAGE_ASSET } from '../../constants/pages'
import { MANAGE_USER, CREATE_ASSET } from 'src/constants/pages';

const NotFound = lazy(() => import("../NotFound"));
const AssetList = lazy(() => import("./List"));
const AssetCreate = lazy(() => import("./Create"));
const AssetUpdate = lazy(() => import("./Update"));

const Asset = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;
  //console.log(role);

  return (
    <>
      {role == Roles.Admin && (
        <Fragment>
          <Route exact path={MANAGE_ASSET}>
            <AssetList/>
          </Route>
          <Route exact path={CREATE_ASSET}>
            <AssetCreate/>
          </Route>
          <Route exact path={EDIT_ASSET}>
            <AssetUpdate/>
          </Route>
        </Fragment>
      )}
      {role == Roles.Staff && (
        <Redirect to={HOME} />
      )}
    </>
  );
}

export default Asset;
