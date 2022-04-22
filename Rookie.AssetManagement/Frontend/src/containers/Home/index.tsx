import React, { Fragment, useEffect, useState } from "react";
import Roles from "src/constants/roles";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Redirect, Route, useHistory } from "react-router-dom";
import { logout } from "../Authorize/reducer";
import { Card, Modal, ModalBody } from "react-bootstrap";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";
import HomeAssignmentList from "./List";
import { HOME } from "src/constants/pages";


const Home = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const role = account?.role;
  const history = useHistory();
  if (account?.firstLogin || account?.isDisable) {
    dispatch(logout());
    history.push("/login");
  }

 
  return (
    <>
      <Route exact path={HOME}>
        <HomeAssignmentList/>
      </Route>
    </>
  );
};

export default Home;
