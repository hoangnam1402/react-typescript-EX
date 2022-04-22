import { useField } from 'formik';
import React, {useState, useEffect, InputHTMLAttributes } from 'react'
import { Modal } from 'react-bootstrap';
import { Search } from 'react-feather';
import CustomTable from 'src/components/Table/CustomTable';
import { ACCSENDING, DECSENDING, DEFAULT_PAGE_LIMIT, DEFAULT_USER_SORT_COLUMN_NAME } from 'src/constants/paging';
import { AdminUserType, AdminUserTypeLabel, StaffUserTypeLabel } from 'src/constants/User/UserConstants';
import { getUsers } from 'src/containers/User/reducer';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IColumnOption from 'src/interfaces/IColumnOption';
import IQueryUserModel from 'src/interfaces/User/IQueryUserModel';
import IUser from 'src/interfaces/User/IUser';

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
  name: string;
  onShow: (values?: boolean) => void,
};

export const AssignmentViewUser: React.FC<InputFieldProps> = (props) => {
  const [field, { value }, { setValue }] = useField(props);
  const { name, onShow } = props;

  const dispatch = useAppDispatch()
  const { users } = useAppSelector((state) => state.userReducer)

  const [query, setQuery] = useState({
    page: users?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_USER_SORT_COLUMN_NAME
  } as IQueryUserModel);    

  const columns: IColumnOption[] = [
    { columnName: "", columnValue: ""},
    { columnName: "Staff Code", columnValue: "staffCode" },
    { columnName: "Full Name", columnValue: "fullName" },
    { columnName: "Type", columnValue: "type" },
  ];

  const [search, setSearch] = useState("");
  const [selectUser, setSelectUser] = useState<IUser>();

  const handleChangeSearch = (e) => {
      e.preventDefault();

      const search = e.target.value;
      setSearch(search);
  };

  const handleSearch = () => {
    setQuery({
      ...query,
      search,
      page: 1
    });
  };

  const handlePage = (page: number) => {
    setQuery({
      ...query,
      page,
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

  const getUserTypeName = (id: number) => {
    return id == AdminUserType ? AdminUserTypeLabel : StaffUserTypeLabel;
  };  

  const Save = () => {
    setValue(selectUser);
    onShow(false);
  }

  const handleClose = () => {
    onShow(false);
    setSelectUser(undefined);
  }
      
  const fetchData = () => {
    dispatch(getUsers(query));
    setSelectUser(undefined);
  }
  
  useEffect(() => {
      fetchData();
  }, [query]);

  return (
    <Modal show={true} onHide={() => onShow(false)} size='lg'
      dialogClassName="modal-dialog-centered" 
      aria-labelledby="contained-modal-title-vcenter">
      <Modal.Header className="modalHeaderContainer">
        <div className="primaryColor text-title intro-x">
          Select User
        </div>
        <div className="d-flex align-items-center w-ld ml-auto intro-x">
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
      </Modal.Header>
      <Modal.Body className="show-grid">
        <CustomTable
          columns={columns}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
          page={{
            currentPage: users?.currentPage,
            totalPage: users?.totalPages,
            handleChange: handlePage,
          }}
        >
          {users?.items.map((data, index) => (
            <tr
              key={index}
              className=""
            >
              <th scope="row" className="checkRow">
                <input
                    type="radio"
                    className=""
                    name="selectUser"
                    checked = {value == data || selectUser == data}
                    onChange={() => setSelectUser(data)}
                />
              </th>
              <td className="py-1">{data.staffCode}</td>
              <td className="py-1">{data.firstName} {data.lastName}</td>
              <td className="py-1">{getUserTypeName(data.type)}</td>
              <td></td>
            </tr>
          ))}
        </CustomTable>
      </Modal.Body>
      <Modal.Footer className="viewUserFooter">
      <div className="text-center mt-3">
          <button
            className="btn btn-danger mr-3"
            onClick={Save}
            type="button"
            disabled={!selectUser}
          >
            Save
          </button>
          <button
            className="btn btn-outline-secondary"
            onClick={handleClose}
            type="button"
          >
            Cancel
          </button>
        </div>
      </Modal.Footer>
    </Modal>
  )
}