import React from "react";
import { Button, Modal } from "react-bootstrap";
import { XSquare } from "react-bootstrap-icons";

import { AssetState, AssignmentState } from "src/constants/States";
import IAssignment from "src/interfaces/Assignment/IAssignment";

type Props = {
  homeAssignment: IAssignment;
  handleClose: () => void;
};

const Info: React.FC<Props> = ({ homeAssignment, handleClose }) => {
  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="containerModalErr"
        contentClassName="modal-650w"
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
              <div className="col-8">{homeAssignment.asset.code}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Asset Name</div>
              <div className="col-8">{homeAssignment.asset.name}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Specification</div>
              <div className="col-8">{homeAssignment.asset.specification}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Assigned to</div>
              <div className="col-8">{homeAssignment.assignTo.userName}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Assigned by</div>
              <div className="col-8">{homeAssignment.assignBy.userName}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Assigned Date</div>
              <div className="col-8">{new Date(homeAssignment.assignDate).toLocaleDateString('en-GB')}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">State</div>
              <div className="col-8">{AssignmentState[homeAssignment.state]}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Note</div>
              <div className="col-8">{homeAssignment.note}</div>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default Info;
