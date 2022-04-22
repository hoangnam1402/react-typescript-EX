import React, { useEffect, useState } from "react";
import { Redirect, useParams } from "react-router";

import { HOME } from "src/constants/pages";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import AssignmentForm from "../AssignmentForm";
import IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";
import Roles from "src/constants/roles";

const UpdateAssignmentContainer = () => {
	const { isAuth, account } = useAppSelector((state) => state.authReducer);
	const dispatch = useAppDispatch();
	const role = account?.role;

	const { assignments } = useAppSelector((state) => state.assignmentReducer);

	const [assignment, setAssignment] = useState(
		undefined as IAssignmentForm | undefined,
	);

	const { id } = useParams<{ id: string }>();

	const existAssignment = assignments?.items.find(
		(item) => item.id === Number(id),
	);

	useEffect(() => {
		if (existAssignment) {
			setAssignment({
				id: existAssignment.id,
				assignToId: existAssignment.assignToID,
				assignTo: existAssignment.assignTo,
				assetId: existAssignment.assetID,
				asset: existAssignment.asset,
				assignDate: existAssignment.assignDate,
				note: existAssignment.note,
			});
		}
	}, [existAssignment]);

	return (
		<>
			{role == Roles.Admin && (
				<div className="ml-5">
					<div className="primaryColor text-title intro-x">
						Update Assignment
					</div>

					<div className="row">
						{assignment && (
							<AssignmentForm initialAssignmentForm={assignment} />
						)}
					</div>
				</div>
			)}
			{role == Roles.Staff && <Redirect to={HOME} />}
		</>
	);
};

export default UpdateAssignmentContainer;
