import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';

import TextField from 'src/components/FormInputs/TextField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import { MANAGE_ASSET } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { createAsset, getAssetCategories, updateAsset } from './reducer';
import IAssetForm from 'src/interfaces/Asset/IAssetForm';
import TextAreaField from 'src/components/FormInputs/TextAreaField';
import { AssetStateOptions, AssetStateCreateOptions } from "src/constants/selectOptions";
import createCategorySelectOption from 'src/utils/createCategorySelectOption';
import ISelectOption from 'src/interfaces/ISelectOption';
import CheckboxFieldCustom from 'src/components/FormInputs/CheckboxFieldCustom';

const initialFormValues: IAssetForm = {
    name: '',
    specification: '',
    state: undefined,
    installDate: undefined,
    categoryID: undefined,
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    specification: Yup.string().required('Required'),
    state: Yup.string().required('Required'),
    installDate: Yup.date().nullable().required('Required'),
    categoryID: Yup.string().required('Required'), 
});

type Props = {
    initialAssetForm?: IAssetForm;
};

const AssetFormContainer: React.FC<Props> = ({ initialAssetForm = {
    ...initialFormValues
} }) => {
    const [loading, setLoading] = useState(false);

    const dispatch = useAppDispatch();

    const fetchData = () => {
        dispatch(getAssetCategories());
    };
    
    useEffect(() => {
        fetchData();
    }, []);

    const { assetCategories } = useAppSelector(
        (state) => state.assetReducer
      );

    const categories = createCategorySelectOption(assetCategories);

    categories.shift();

    const selectOptions: ISelectOption[] = categories;

    const isUpdate = initialAssetForm.id ? true : false;

    const history = useHistory();
    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Asset ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                history.push(MANAGE_ASSET);
            }, 1000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    return (
        <Formik
            initialValues={initialAssetForm}
            enableReinitialize
            validationSchema={validationSchema}
            isInitialValid={false}
            onSubmit={(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(updateAsset({ handleResult, formValues: values }));
                        console.log("UpdateASSET: ")
                        console.log(values)
                    }
                    else {
                        console.log("values:");
                        console.log(values);
                        dispatch(createAsset({ handleResult, formValues: values }));
                    }

                    setLoading(false);
                }, 1000);
            }}
        >
            {({isValid}) => (
                <Form className='intro-y col-lg-12 col-12'>
                    <TextField id="name"
                        name="name" 
                        label="Name" 
                        isrequired="true"/>
                    <SelectField id="categoryID"
                        name="categoryID"
                        label="Category"
                        isrequired="true"
                        disabled={isUpdate ? true : false}
                        options={selectOptions}  
                        defaultValue={isUpdate ? initialAssetForm.categoryID : 0}
                        />
                    <TextAreaField id="specification"
                        name="specification" 
                        label="Specification" 
                        isrequired={true}
                        />
                    <DateField id='installDate'
                        name="installDate"
                        label="Installed Date"
                        isrequired={true} />
                    <CheckboxFieldCustom id="state"
                        name="state"
                        label="State" 
                        isrequired={true}
                        options={isUpdate ? AssetStateOptions : AssetStateCreateOptions}
                        defaultValue={initialAssetForm.state} />
                    
                    <div className="d-flex">
                        <div className="ml-auto">
                            <button className="btn btn-danger" id='create'
                                type="submit" disabled={(!isValid||loading)}
                            >
                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                            </button>

                            <Link to={MANAGE_ASSET} className="btn btn-outline-secondary ml-2" id='cancel'>
                                Cancel
                            </Link>
                        </div>
                    </div>
                </Form>
            )}
        </Formik>
    );
}

export default AssetFormContainer;
