import React from "react";
import { Button, Modal } from "react-bootstrap";
import { XSquare } from "react-bootstrap-icons";

import IAsset from "src/interfaces/Asset/IAsset";
import {
  LocationHCMType,
  LocationHCMTypeLabel,
  LocationHNTypeLabel,
} from "src/constants/User/LocationContants";
import {
	StateAvailable,
	StateNotAvailable,
	StateAssigned,
	StateWaitingForRecycling,
  StateRecycled,
	StateAvailableLable,
	StateNotAvailableLabel,
	StateAssignedLabel,
	StateWaitingForRecyclingLabel,
  StateRecycledLabel
} from "src/constants/Asset/StateConstant";
import IColumnOption from "src/interfaces/IColumnOption";

const columns: IColumnOption[] = [
  { columnName: "Date", columnValue: "date" },
  { columnName: "Assigned to", columnValue: "assignedTo" },
  { columnName: "Assigned by", columnValue: "assignedBy" },
  { columnName: "Return Date", columnValue: "returnDate" },
];

type Props = {
  asset: IAsset;
  handleClose: () => void;
};

const Info: React.FC<Props> = ({ asset, handleClose }) => {
	const getAssetLocationTypeName = (id: number) => {
		return id == LocationHCMType ? LocationHCMTypeLabel : LocationHNTypeLabel;
	};
	
	const getAssetStateTypeName = (id: number) => {
		switch(id) {
			case StateAvailable:
				return StateAvailableLable;
				break;
			case StateNotAvailable:
				return StateNotAvailableLabel;
				break;
			case StateWaitingForRecycling:
				return StateWaitingForRecyclingLabel;
				break;
			case StateRecycled:
				return StateRecycledLabel;
				break;
			default:
				return StateAssignedLabel;
		}
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
            Detailed Asset Information
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
              <div className="col-8">{asset.code}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Asset Name</div>
              <div className="col-8">{asset.name}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Category</div>
              <div className="col-8">{asset.category.name}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Installed Date</div>
              <div className="col-8">{new Date(asset.installDate).toLocaleDateString('en-GB')}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">State</div>
              <div className="col-8">{getAssetStateTypeName(asset.state)}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Location</div>
              <div className="col-8">{getAssetLocationTypeName(asset.location)}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">Specification</div>
              <div className="col-8">{asset.specification}</div>
            </div>

            <div className="row -intro-y mt-2">
              <div className="col-4">History</div>
              <div className="col-8">
								<div className="table-container">
								<table className="table">
									<thead>
										<tr className="text center text-lg-nowrap">
												<th><a className="btn">Date</a></th>
												<th><a className="btn">Assigned to</a></th>
												<th><a className="btn">Assigned by</a></th>
												<th><a className="btn">Returned Date</a></th>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td className="py-1">12/10/2018</td>
											<td className="py-1">hungtv1</td>
											<td className="py-1">binhnv</td>
											<td className="py-1">07/03/2019</td>
											<td className="py-1"></td>
										</tr>
										<tr>
											<td className="py-1">10/03/2019</td>
											<td className="py-1">thinhptx</td>
											<td className="py-1">tuanha</td>
											<td className="py-1">22/03/2020</td>
											<td className="py-1"></td>
										</tr>
									</tbody>
								</table>
              	</div>
            	</div>
						</div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default Info;
