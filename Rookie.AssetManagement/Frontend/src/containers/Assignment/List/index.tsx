import React, { useEffect, useState } from "react";
import {
  CalendarDateFill,
  FunnelFill,
  Calendar2XFill,
} from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";

import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { Link } from "react-router-dom";
import ISelectOption from "src/interfaces/ISelectOption";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_USER_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT,
} from "src/constants/paging";
import {
  CREATE_ASSET,
  CREATE_ASSIGNMENT,
  CREATE_USER,
} from "src/constants/pages";
import {
  AssetStateOptions,
  AssignmentStateOptions,
} from "src/constants/selectOptions";
import AssignmentTable from "./AssignmentTable";
import { getAssetCategories, getAssets } from "src/containers/Asset/reducer";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignment";
import { getAssignments } from "../reducer";
import DateField from "src/components/FormInputs/DateField";
import DatePicker from "react-datepicker";
const AssignmentList = () => {
  const dispatch = useAppDispatch();
  const { assignments, loading, newAssignment, deleteAssignment } =
    useAppSelector((state) => state.assignmentReducer);

  const [query, setQuery] = useState({
    page: assignments?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_USER_SORT_COLUMN_NAME,
    assignedDate: undefined,
  } as IQueryAssignmentModel);

  const stateSelectOptions: ISelectOption[] = AssignmentStateOptions;
  const [stateSelected, setStateSelected] = useState([
    { id: 0, label: "All", value: 0 },
  ] as ISelectOption[]);

  const handleState = (selected: ISelectOption[]) => {
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
        page: 1,
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
      page: 1,
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

  function handleDateChange(date: Date) {
    date.setHours(date.getHours() + 8);
    console.log(date.toISOString());
    setQuery({
      ...query,
      assignedDate: date,
      page: 1,
    });
  }

  function handleResetDateFilter() {
    setQuery({
      ...query,
      assignedDate: undefined,
    });
  }

  const fetchData = () => {
    dispatch(getAssignments(query));
  };

  useEffect(() => {
    fetchData();
  }, [query, deleteAssignment]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Assignment List</div>

      <div>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center w-md mr-5">
            <div className="d-flex justify-content-center">
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
          <div className="d-flex align-items-center w-md ">
            <div className="d-flex justify-content-center">
              <div className="mt-2 row">
                <div className="col">
                  <label className="border d-flex align-items-center w-100">
                    <DatePicker
                      placeholderText="  Assigned Date"
                      selected={query.assignedDate}
                      onChange={handleDateChange}
                      dateFormat="dd/MM/yyyy"
                    />
                    <div
                      className="p-2 border border-l border-5"
                      style={{ justifyContent: "space-around" }}
                    >
                      <CalendarDateFill />
                    </div>
                  </label>
                </div>
              </div>
            </div>
          </div>

          <div className="d-flex align-items-center w-md ml-auto">
            <div className="input-group margin_input">
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
            <Link
              to={CREATE_ASSIGNMENT}
              type="button"
              className="btn btn-danger"
            >
              Create new Assignment
            </Link>
          </div>
        </div>

        <AssignmentTable
          page={query.page}
          assignments={assignments}
          handlePage={handlePage}
          deleteAssignment={deleteAssignment}
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

export default AssignmentList;
