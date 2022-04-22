import React, { ReactElement, useEffect, useState } from "react";
import {
	PencilFill,
	XCircle,
	ArrowCounterclockwise,
} from "react-bootstrap-icons";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from "react-notifications";
import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";

import { AssetState, AssignmentState } from "src/constants/States";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import { getFormatDateTime } from "src/utils/formatDateTimeddMMyyyy";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { useHistory } from "react-router-dom";
import Info from "../Info";
import { deleteAssignments, setNewAssignment } from "../reducer";
import DeleteModal from "src/components/DeleteModal";
import { EDIT_ASSIGNMENT_ID } from "src/constants/pages";

const columns: IColumnOption[] = [
	{ columnName: "No.", columnValue: "" },
	{ columnName: "Asset Code", columnValue: "code" },
	{ columnName: "Asset Name", columnValue: "name" },
	{ columnName: "Assigned to", columnValue: "AssignToID" },
	{ columnName: "Assigned by", columnValue: "AssignByID" },
	{ columnName: "Assigned Date", columnValue: "assignDate" },
	{ columnName: "State", columnValue: "state" },
];

type Props = {
	assignments: IPagedModel<IAssignment> | null;
	handlePage: (page: number) => void;
	handleSort: (colValue: string) => void;
	sortState: SortType;
	fetchData: Function;
	page: number;
	deleteAssignment?: IAssignment;
};

const AssignmentTable: React.FC<Props> = ({
	assignments,
	handlePage,
	handleSort,
	sortState,
	fetchData,
	page,
	deleteAssignment,
}) => {
	const dispatch = useAppDispatch();
	const { status, newAssignment } = useAppSelector(
		(state) => state.assignmentReducer,
	);
	const [showConfirmDelete, setShowConfirmDelete] = useState(false);
	const [assetDetail, setAssetDetail] = useState(null as IAssignment | null);
	const [showDetail, setShowDetail] = useState(false);
	const [assignmentDetail, setAssignmentDetail] = useState(
		null as IAssignment | null,
	);

	const handleResult = (result: boolean) => {
		if (result) {
			NotificationManager.success(
                `Delete Successful Assignment`,
                `Delete Successful`,
                2000,
            );
			deleteAssignment = undefined;
		} else {
			NotificationManager.error("Delete Failed");
		}
	};

	const handleShowInfo = (
		assetCode: string,
		assignToID: number,
		assignDate: Date,
	) => {
		const assignment = assignments?.items.find(
			(item) =>
				item.asset.code == assetCode &&
				item.assignToID == assignToID &&
				item.assignDate == assignDate,
		);

		if (assignment) {
			setAssignmentDetail(assignment);
			setShowDetail(true);
		} else if (newAssignment) {
			setAssignmentDetail(newAssignment);
			setShowDetail(true);
		}
	};

	const handleCloseDetail = () => {
		setShowDetail(false);
	};

	const handleDelete = (id: number) => {
		const assignment = assignments?.items.find((item) => item.id == id);

		if (assignment) {
			setShowConfirmDelete(true);
			setAssetDetail(assignment);
		}
	};

	const handleAcceptDelete = () => {
		if (assetDetail) {
			setShowConfirmDelete(false);
			dispatch(deleteAssignments({ handleResult, formValues: assetDetail }));
		}
	};

	const handleCancleDelete = () => {
		setShowConfirmDelete(false);
	};
	const history = useHistory();
	const handleEdit = (id: number) => {
		history.push(EDIT_ASSIGNMENT_ID(id));
	};
	useEffect(
		() => () => {
			dispatch(setNewAssignment(undefined));
		},
		[],
	);
	function NewCreatedContent(): ReactElement {
		return (
			<tr
			// key={99}
			// className=""
			// onClick={() => handleShowInfo(newAssignment!.code)}
			>
				<td className="py-1">{newAssignment!.asset.name}</td>
				<td className="py-1">{newAssignment!.assignBy.userName}</td>
				<td className="py-1">{newAssignment!.assignDate}</td>
				<td className="py-1">{newAssignment!.note}</td>

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
					currentPage: assignments?.currentPage,
					totalPage: assignments?.totalPages,
					handleChange: handlePage,
				}}
			>
				{newAssignment && NewCreatedContent()}
				{assignments?.items.map((data, index) => (
					<tr
						key={index}
						className=""
						onClick={() =>
							handleShowInfo(data.asset.code, data.assignToID, data.assignDate)
						}
					>
						<td className="py-1">{index + 1 + (page - 1) * 5}</td>
						<td className="py-1">{data.asset.code} </td>
						<td className="py-1">{data.asset.name}</td>
						<td className="py-1">{data.assignTo.userName}</td>
						<td className="py-1">{data.assignBy.userName}</td>
						<td className="py-1">
							{getFormatDateTime(new Date(data.assignDate))}
						</td>
						<td className="py-1">{AssignmentState[data.state]}</td>

						<td className="d-flex py-1">
							<ButtonIcon
								onClick={() => handleEdit(data.id)}
								disable={data.state == 1 ? false : true}
							>
								<PencilFill className="text-black" />
							</ButtonIcon>
							<ButtonIcon
								disable={data.state == 1 ? false : true}
								onClick={() => handleDelete(data.id)}
							>
								<XCircle className="text-danger mx-2" />
							</ButtonIcon>
							<ButtonIcon disable={data.state == 1 ? true : false}>
								<ArrowCounterclockwise
									className={
										data.state == 1 ? "text-secondary" : "text-primary"
									}
								/>
							</ButtonIcon>
						</td>
					</tr>
				))}
			</Table>
			<DeleteModal
				title="Are you sure ?"
				isShow={showConfirmDelete}
				onHide={handleCancleDelete}
			>
				<div>
					<div className="text-center">Do you want to delete this Assignment?</div>
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
			{assignmentDetail && showDetail && (
				<Info assignment={assignmentDetail} handleClose={handleCloseDetail} />
			)}{" "}
		</>
	);
};

export default AssignmentTable;
