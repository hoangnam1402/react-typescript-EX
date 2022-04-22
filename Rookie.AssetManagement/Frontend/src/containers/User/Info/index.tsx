import React from "react";
import { Button, Modal } from "react-bootstrap";
import { XSquare } from "react-bootstrap-icons";

import IUser from "src/interfaces/User/IUser";
import formatDateTime from "src/utils/formatDateTime";
import {
  AdminUserType,
  AdminUserTypeLabel,
  StaffUserTypeLabel,
} from "src/constants/User/UserConstants";
import {
  GenderMale,
  GenderMaleLabel,
  GenderFemaleLabel,
} from "src/constants/User/GenderContants";
import {
  LocationHCMType,
  LocationHCMTypeLabel,
  LocationHNTypeLabel,
} from "src/constants/User/LocationContants";
import { string } from "yup";
import { getFormatDateTime } from "src/utils/formatDateTimeddMMyyyy";

type Props = {
  user: IUser;
  handleClose: () => void;
};

const Info: React.FC<Props> = ({ user, handleClose }) => {
  const getUserTypeName = (id: number) => {
    return id == AdminUserType ? AdminUserTypeLabel : StaffUserTypeLabel;
  };

  const getUserGenderTypeName = (id: string) => {
    return id == GenderMale ? GenderMaleLabel : GenderFemaleLabel;
  };

  const getUserLocationTypeName = (id: number) => {
    return id == LocationHCMType ? LocationHCMTypeLabel : LocationHNTypeLabel;
  };

  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="containerModalErr"
      >
        <Modal.Header className="align-items-center headerModal">
          <Modal.Title id="detail-modal" className="primaryColor">
            Detailed User Information
          </Modal.Title>
          <XSquare
            onClick={handleClose}
            className="primaryColor model-closeIcon"
          />
        </Modal.Header>

        <Modal.Body className="bodyModal">
          <div className="container-fluid">
            <div className="row -intro-y mt-2">
              <div className="col-4">Staff Code</div>
              <div className="col-8">{user.staffCode}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Full Name</div>
              <div className="col-8">{user.fullName}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Username</div>
              <div className="col-8">{user.userName}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Date of Birth</div>
              <div className="col-8">{getFormatDateTime(user.dob)}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Gender</div>
              <div className="col-8">{getUserGenderTypeName(user.gender)}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Joined Date</div>
              <div className="col-8">{getFormatDateTime(user.joinDate)}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Type</div>
              <div className="col-8">{getUserTypeName(user.type)}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Location</div>
              <div className="col-8">
                {getUserLocationTypeName(user.location)}
              </div>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default Info;
