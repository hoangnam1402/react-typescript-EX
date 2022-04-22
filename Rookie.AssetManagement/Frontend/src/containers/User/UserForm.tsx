import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import {MANAGE_USER} from "./../../constants/pages"
import TextField from 'src/components/FormInputs/TextField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import { UserTypeOptions, UserGenderOptions } from "src/constants/selectOptions";
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IUserForm from 'src/interfaces/User/IUserForm';
import { createUserByAdmin, updateUser } from './reducer';

const initialFormValues: IUserForm = {
  gender:"",
  firstName:"",
  lastName:"",
  type: 0,
  DOB: undefined,
  joinDate: undefined
};

const validationSchema = Yup.object().shape({
    firstName: Yup.string().required('Required').matches(/^[aA-zZ\s]+$/, "Invalid First Name format. Only accept string"),
    lastName: Yup.string().required('Required').matches(/^[aA-zZ\s]+$/, "Invalid Last Name format. Only accept string"),
    gender: Yup.string().required('Required'),
    type: Yup.string().required('Required'),
    DOB: Yup.date().nullable().required('Required')
        .max(new Date(Date.now() - 567993600000 - 86400000), "User is under or equal 18. Please select a different date")
        .min(new Date(Date.now() - 1893456000000), "User is over 60. Please select a different date"),
    joinDate: Yup.date().when('DOB', (DOB,a) => {
        if (DOB) { a = new Date(DOB);
            return Yup.date().required('Required').nullable().test('test-joinedDate', 'Joined date is Saturday or Sunday. Please select a different date',
            function (value) {
                if (value) {
                    if (value.getDay() == 0 || value.getDay() == 6) {
                        return false;
                    } else {
                        return true;
                    }
                }
                return false;
            }).min(new Date(a.setFullYear(a.getFullYear() + 18) + 86400000), 'User under or equal the age of 18 may not join company. Please select a different date')
        } else { 
            return Yup.date().required('Required').nullable().test('test-joinedDate', 'Joined date is Saturday or Sunday. Please select a different date',
            function (value) {
                if (value) {
                    if (value.getDay() == 0 || value.getDay() == 6) {
                        return false;
                    } else {
                        return true;
                    }
                }
                return false;
            })
        }
    }),
});

type Props = {
    initialUserForm?: IUserForm;
};

const UserFormContainer: React.FC<Props> = ({ initialUserForm = {
    ...initialFormValues
} }) => {
    const [loading, setLoading] = useState(false);

    const dispatch = useAppDispatch();

    const isUpdate = initialUserForm.userId ? true : false;

    const history = useHistory();

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful User ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                history.push(MANAGE_USER);
         
            }, 1000);
            // setTimeout(() => {
            //     window.location.reload()
            // }, 3000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    return (
        <Formik
            initialValues={initialUserForm}
            enableReinitialize
            validationSchema={validationSchema}
            isInitialValid={false}
            onSubmit={(values) => {
                setLoading(true);
                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(updateUser({ handleResult, formValues: values }));
                        console.log("UpdateUSER")
                        console.log(values)
                    }
                    else {
                        dispatch(createUserByAdmin({handleResult, formValues: values}));
                        console.log(values)
                    }

                    setLoading(false);
                }, 1000);
            }}
        >
            {({isValid}) => (
                <Form className='intro-y col-lg-10 col-10' >
                    <TextField id="firstName"
                        name="firstName" 
                        label="First Name" 
                        isrequired="true"
                        disabled={isUpdate ? true : false} />
                    <TextField id="lastName"
                        name="lastName" 
                        label="Last Name" 
                        isrequired="true"
                        disabled={isUpdate ? true : false} />
                    <DateField id="dateOfBirth"
                        name="DOB"
                        label="Date of Birth"
                        isrequired="true"/>
                    <CheckboxField
                        name="gender"
                        label="Gender"
                        isrequired={true}
                        options={UserGenderOptions}
                        defaultValue={initialUserForm.gender}/>
                    <DateField id="joinDate"
                        name="joinDate"
                        label="Joined Date"
                        isrequired="true"/>
                    <SelectField id="type"
                        name="type" 
                        label="Type"
                        isrequired="true"
                        defaultValue={isUpdate? initialUserForm.type : 0}
                        options={UserTypeOptions}/>

                    <div className="d-flex">
                        <div className="ml-auto">
                            <button className="btn btn-danger" id="createUserByAdmin"
                                type="submit" disabled={(!isValid || loading)}
                            >
                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                            </button>

                            <Link to={MANAGE_USER} className="btn btn-outline-secondary ml-2" id="cancel">
                                Cancel
                            </Link>
                        </div>
                    </div>
                </Form>
            )}
        </Formik>
    );
}

export default UserFormContainer;