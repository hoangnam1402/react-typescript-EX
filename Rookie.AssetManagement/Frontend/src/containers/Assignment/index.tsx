import React, { Fragment, lazy, useEffect, useState } from "react";
import Roles from "src/constants/roles";
import { useAppDispatch, useAppSelector } from "../../hooks/redux";
import { Redirect, Route, Switch } from "react-router-dom";
import { Link, useHistory } from "react-router-dom";
import {
	CREATE_ASSIGNMENT,
	EDIT_ASSIGNMENT,
	HOME,
	MANAGE_ASSIGNMENT,
} from "../../constants/pages";

const NotFound = lazy(() => import("../NotFound"));
const AssignmentList = lazy(() => import("./List"));
const AssignmentCreate = lazy(() => import("./Create"));
const AssignmentUpdate = lazy(() => import("./Update"));
const Assignment = () => {
	const { isAuth, account } = useAppSelector((state) => state.authReducer);
	const dispatch = useAppDispatch();
	const role = account?.role;
	//console.log(role);

	return (
		<>
			{role == Roles.Admin && (
				<Fragment>
					<Route exact path={MANAGE_ASSIGNMENT}>
						<AssignmentList />
					</Route>
					<Route exact path={CREATE_ASSIGNMENT}>
						<AssignmentCreate />
					</Route>
					<Route exact path={EDIT_ASSIGNMENT}>
						<AssignmentUpdate />
					</Route>
				</Fragment>
			)}
			{role == Roles.Staff && <Redirect to={HOME} />}
		</>
	);
};

export default Assignment;
