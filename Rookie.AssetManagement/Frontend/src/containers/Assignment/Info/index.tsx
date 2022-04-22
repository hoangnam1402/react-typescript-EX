import React from "react";
import { Button, Modal } from "react-bootstrap";
import { XSquare } from "react-bootstrap-icons";

import IAssignment from "src/interfaces/Assignment/IAssignment";
import { AssignmentState } from "src/constants/States";

type Props = {
	assignment: IAssignment;
	handleClose: () => void;
};

const Info: React.FC<Props> = ({ assignment, handleClose }) => {

	return (
		<>
			<Modal
				show={true}
				onHide={handleClose}
				dialogClassName="containerModalErr"
			>
				<Modal.Header className="align-items-center headerModal">
					<Modal.Title id="detail-modal" className="primaryColor">
						Detailed Assignment Information
					</Modal.Title>
					<XSquare
						onClick={handleClose}
						className="primaryColor model-closeIcon"
					/>
				</Modal.Header>

				<Modal.Body className="bodyModal">
					<div className="container-fluid">
						<div className="row -intro-y mt-2">
							<div className="col-4">Asset Code</div>
							<div className="col-8">{assignment.asset.code}</div>
						</div>

						<div className="row -intro-y mt-2">
							<div className="col-4">Asset Name</div>
							<div className="col-8">{assignment.asset.name}</div>
						</div>

						<div className="row -intro-y mt-2">
							<div className="col-4">Specification</div>
							<div className="col-8">{assignment.asset.specification}</div>
						</div>

						<div className="row -intro-y mt-2">
							<div className="col-4">Assigned to</div>
							<div className="col-8">{assignment.assignTo.userName}</div>
						</div>

						<div className="row -intro-y mt-2">
							<div className="col-4">Assigned by</div>
							<div className="col-8">{assignment.assignBy.userName}</div>
						</div>

						<div className="row -intro-y mt-2">
							<div className="col-4">Assigned Date</div>
							<div className="col-8">
								{new Date(assignment.assignDate).toLocaleDateString("en-GB")}
							</div>
						</div>

						<div className="row -intro-y mt-2">
							<div className="col-4">State</div>
							<div className="col-8">{AssignmentState[assignment.state]}</div>
						</div>

						<div className="row -intro-y mt-2">
							<div className="col-4">Note</div>
							<div className="col-8">{assignment.note}</div>
						</div>
					</div>
				</Modal.Body>
			</Modal>
		</>
	);
};

export default Info;
