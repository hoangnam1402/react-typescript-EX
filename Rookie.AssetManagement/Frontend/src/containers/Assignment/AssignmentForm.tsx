import React, { useEffect, useState } from "react";
import { Formik, Form, Field } from "formik";
import * as Yup from "yup";
import { Link, useHistory } from "react-router-dom";
import { NotificationManager } from "react-notifications";

import TextField from "src/components/FormInputs/TextField";
import DateField from "src/components/FormInputs/DateField";
import { MANAGE_ASSIGNMENT } from "src/constants/pages";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { createAssignments, updateAssignment } from "./reducer";
import TextAreaField from "src/components/FormInputs/TextAreaField";
import { date } from "yup/lib/locale";
import IUser from "src/interfaces/User/IUser";
import { AssignmentViewUser } from "./Create/AssignmentViewUser";
import { AssignmentViewAsset } from "./Create/AssignmentViewAsset";
import IAsset from "src/interfaces/Asset/IAsset";
import ClickToShowField from "src/components/FormInputs/ClickToShowField";
import  IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";

const initialFormValues: IAssignmentForm = {
	assignDate: new Date(),
	asset: undefined,
	assignTo: undefined,
	note: "",
};

const validationSchema = Yup.object().shape({
	asset: Yup.object().required("Required"),
	assignTo: Yup.object().required("Required"),
	note: Yup.string().required("Required"),
	assignDate: Yup.date()
		.required("Required")
		.nullable()
		.test(
			"test-assignDate",
			"Assigned date is Saturday or Sunday. Please select a different date",
			function (value) {
				if (value) {
					if (value.getDay() == 0 || value.getDay() == 6) {
						return false;
					} else {
						return true;
					}
				}
				return false;
			},
		),
});

type Props = {
	initialAssignmentForm?: IAssignmentForm;
};

const AssignmentFormContainer: React.FC<Props> = ({
	initialAssignmentForm = {
		...initialFormValues,
	},
}) => {
	const [loading, setLoading] = useState(false);
	const dispatch = useAppDispatch();

	const isUpdate = initialAssignmentForm.id ? true : false;

	const history = useHistory();

	const [modalUserShow, setModalUserShow] = useState<boolean>();
	const [modalAssetShow, setModalAssetShow] = useState<boolean>();

    const handleClose = () => {
        setModalUserShow(false);
        setModalAssetShow(false);
    }

	const handleResult = (result: boolean) => {
		if (result) {
			NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Assignment`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );
			setTimeout(() => {
				history.push(MANAGE_ASSIGNMENT);
			}, 1000);
		} else {
			NotificationManager.error("Create failed");
		}
	};

	return (
		<Formik
			initialValues={initialAssignmentForm}
			enableReinitialize
			validationSchema={validationSchema}
			isInitialValid={false}
			onSubmit={(values) => {
				setLoading(true);

				setTimeout(() => {
					if (isUpdate) {
						values.assetId = values.asset?.id;
						values.assignToId = values.assignTo?.id;
						dispatch(updateAssignment({ handleResult, formValues: values }));
						console.log("Update");
					} 
					else {
						const inputValues = {
							assignDate: values.assignDate,
							assetId: values.asset?.id,
							assignToId: values.assignTo?.id,
							note: values.note,
						};
						dispatch(
							createAssignments({ handleResult, formValues: inputValues }),
						);
					}
					setLoading(false);
				}, 1000);
			}}
		>
			{({ isValid, values }) => (
				<>
					<Form className="intro-y col-lg-12 col-12">
						<ClickToShowField
							id="user"
							name="assignTo"
							label="User"
							isrequired="true"
							value={values.assignTo?.fullName}
							onClick={() => setModalUserShow(true)}
						/>
						<ClickToShowField
							id="asset"
							name="asset"
							label="Asset"
							isrequired="true"
							value={values.asset?.name}
							onClick={() => setModalAssetShow(true)}
						/>
						<DateField
							id="assignDate"
							name="assignDate"
							label="Assigned Date"
							minDate={new Date()}
							isrequired="true"
						/>
						<TextAreaField
							id="note"
							name="note"
							label="Note"
							isrequired="true"
						/>
						<div className="d-flex">
							<div className="ml-auto">
								<button
									className="btn btn-danger"
									id="create"
									type="submit"
									disabled={!isValid || loading}
								>
									Save{" "}
									{loading && (
										<img
											src="/oval.svg"
											className="w-4 h-4 ml-2 inline-block"
										/>
									)}
								</button>

                            <Link to={MANAGE_ASSIGNMENT} className="btn btn-outline-secondary ml-2" id='cancel'>
                                Cancel
                            </Link>
                        </div>
                    </div>
                </Form>
                {modalUserShow && (
                <AssignmentViewUser 
                    onShow={handleClose}
                    name="assignTo"/>
                )}
                {modalAssetShow && (
                <AssignmentViewAsset 
                    onShow={handleClose} 
                    name="asset"/>
                )}
                </>
            )}
        </Formik>
    );
}

export default AssignmentFormContainer;
