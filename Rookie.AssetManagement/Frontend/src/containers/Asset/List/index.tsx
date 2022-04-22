import React, { useEffect, useState } from "react";
import { FunnelFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";

import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import IUserUserModel from "src/interfaces/User/IQueryUserModel";
import { getAssets, getAssetCategories } from "../reducer";
import { Link } from "react-router-dom";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import ISelectOption from "src/interfaces/ISelectOption";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_USER_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "src/constants/paging";
import { CREATE_ASSET, CREATE_USER } from "src/constants/pages";
import AssetTable from "./AssetTable";
import createCategorySelectOption from "src/utils/createCategorySelectOption";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import { AssetStateOptions } from "src/constants/selectOptions";

const AssetList = () => {
  const dispatch = useAppDispatch();
  const { assets, assetCategories, loading, deleteAsset } = useAppSelector(
    (state) => state.assetReducer
  );

  const [query, setQuery] = useState({
    page: assets?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_USER_SORT_COLUMN_NAME,
  } as IQueryAssetModel);

  const selectOptions: ISelectOption[] =
    createCategorySelectOption(assetCategories);

  const [selectedType, setSelectedType] = useState(
    selectOptions as ISelectOption[]
  );

  const stateSelectOptions: ISelectOption[] = AssetStateOptions;
  const [stateSelected, setStateSelected] = useState([
    { id: 0, label: "All", value: 0 },
  ] as ISelectOption[]);

  const handleType = (selected: ISelectOption[]) => {
    if (selected.length === 0) {
      setQuery({
        ...query,
        category: [],
      });

      setSelectedType([selectOptions[0]]);
      return;
    }

    const selectedAll = selected.find((item) => item.id === 0);

    setSelectedType((prevSelected) => {
      if (!prevSelected.some((item) => item.id === 0) && selectedAll) {
        setQuery({
          ...query,
          category: [],
        });

        return [selectedAll];
      }

      const newSelected = selected.filter((item) => item.id !== 0);
      const category = newSelected.map((item) => item.value as number);

      setQuery({
        ...query,
        category,
        page:1
      });

      return newSelected;
    });
  };
  const handleState = (selected: ISelectOption[]) => {
    console.log("handelState");
    if (selected.length === 0) {
      setQuery({
        ...query,
        state: [],
        
      });

      setStateSelected([stateSelectOptions[0]]);
      return;
    }

    const selectedAll = selected.find((item) => item.id === 0);

    setStateSelected((prevSelected) => {
      if (!prevSelected.some((item) => item.id === 0) && selectedAll) {
        setQuery({
          ...query,
          state: [],
   
        });

        return [selectedAll];
      }

      const newSelected = selected.filter((item) => item.id !== 0);
      const state = newSelected.map((item) => item.value as number);

      setQuery({
        ...query,
        state,
        page:1
      });

      return newSelected;
    });
  };
  const [search, setSearch] = useState("");

  const handleChangeSearch = (e) => {
    e.preventDefault();

    const search = e.target.value;
    setSearch(search);
  };

  const handlePage = (page: number) => {
    setQuery({
      ...query,
      page,
    });
  };

  const handleSearch = () => {
    setQuery({
      ...query,
      search,
      page:1
    });
  };

  const handleSort = (sortColumn: string) => {
    const sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;

    setQuery({
      ...query,
      sortColumn,
      sortOrder,
    });
  };

  const fetchData = () => {
    dispatch(getAssets(query));
    dispatch(getAssetCategories());
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteAsset,stateSelected]);

  useEffect(() => {
      const option = [
        { id: 0, label: "All", value: 0 },
      ]
      setSelectedType(option);


  }, [])
  
  console.log(stateSelected)
  return (
    <>
      <div className="primaryColor text-title intro-x">Asset List</div>

      <div>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <p className="mr-2 mt-2">State:</p>
              <ReactMultiSelectCheckboxes
                options={stateSelectOptions}
                hideSearch={true}
                placeholderButtonLabel="State"
                value={stateSelected}
                onChange={handleState}
              />

              <div className="border p-2">
                <FunnelFill />
              </div>
            </div>
          </div>
          <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
              <p className="mr-2 mt-2">Category:</p>
              <ReactMultiSelectCheckboxes
                options={selectOptions}
                hideSearch={true}
                placeholderButtonLabel="Type"
                value={selectedType}
                onChange={handleType}
              />
              <div className="border p-2">
                <FunnelFill />
              </div>{" "}
            </div>
          </div>

          <div className="d-flex align-items-center w-ld ml-auto">
            <div className="input-group">
              <input
                onChange={handleChangeSearch}
                value={search}
                type="text"
                className="form-control"
              />
              <span onClick={handleSearch} className="border p-2 pointer">
                <Search />
              </span>
            </div>
          </div>

          <div className="d-flex align-items-center ml-3">
            <Link to={CREATE_ASSET} type="button" className="btn btn-danger">
              Create new Asset
            </Link>
          </div>
        </div>

        <AssetTable
          assets={assets}
          deleteAsset={deleteAsset}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
          fetchData={fetchData}
        />
      </div>
    </>
  );
};

export default AssetList;
