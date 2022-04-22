import React, { ReactElement, useEffect, useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from "react-notifications";

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IUser from "src/interfaces/User/IUser";

import {
  StaffUserTypeLabel,
  AdminUserType,
  AdminUserTypeLabel,
} from "src/constants/User/UserConstants";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import Info from "../Info";
import { Console } from "console";
import { setNewUser } from "../reducer";
import { EDIT_USER_ID } from "src/constants/pages";

const columns: IColumnOption[] = [
  { columnName: "Staff Code", columnValue: "staffCode" },
  { columnName: "Full Name", columnValue: "fullName" },
  { columnName: "Username", columnValue: "userName" },
  { columnName: "Joined Date", columnValue: "joinDate" },
  { columnName: "Type", columnValue: "type" },
];

type Props = {
  users: IPagedModel<IUser> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
};

const UserTable: React.FC<Props> = ({
  users,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const dispatch = useAppDispatch();
  const {status , newUser} = useAppSelector((state) => state.userReducer);

  const [showDetail, setShowDetail] = useState(false);
  const [userDetail, setUserDetail] = useState(null as IUser | null);


  const handleShowInfo = (staffCode: string) => {
    const user = users?.items.find((item) => item.staffCode == staffCode);

    if (user) {
      setUserDetail(user);
      setShowDetail(true);
    }
    else if(newUser){
      setUserDetail(newUser);
      setShowDetail(true);
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (id: number) => {
    history.push(EDIT_USER_ID(id));
  };

  const getUserTypeName = (id: number) => {
    return id == AdminUserType ? AdminUserTypeLabel : StaffUserTypeLabel;
  };

  useEffect( () => () => {dispatch(setNewUser(undefined))}, [] );

 function NewCreatedContent(): ReactElement{
    return (
      <tr
        key={99}
        className=""
        onClick={() => handleShowInfo(newUser!.staffCode)}
      >
        <td className="py-1">{newUser!.staffCode}</td>
        <td className="py-1">
          {newUser!.firstName} {newUser!.lastName}
        </td>
        <td className="py-1">{newUser!.userName}</td>
        <td className="py-1">
          {new Date(newUser!.joinDate).toLocaleDateString('en-GB')}
        </td>
        <td className="py-1">{getUserTypeName(newUser!.type)}</td>

        <td className="d-flex py-1">
          <ButtonIcon>
            <PencilFill className="text-black" />
          </ButtonIcon>
          <ButtonIcon>
            <XCircle className="text-danger mx-2" />
          </ButtonIcon>
        </td>
      </tr>
    );
  }

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: users?.currentPage,
          totalPage: users?.totalPages,
          handleChange: handlePage,
        }}
      >
        {/* {newUser && NewCreatedContent()} */}
        {users?.items.map((data, index) => (
          <tr
            key={index}
            className=""
            onClick={() => handleShowInfo(data.staffCode)}
          >
            <td className="py-1">{data.staffCode}</td>
            <td className="py-1">
              {data.firstName} {data.lastName}
            </td>
            <td className="py-1">{data.userName}</td>
            <td className="py-1">
              {new Date(data.joinDate).toLocaleDateString('en-GB')}
            </td>
            <td className="py-1">{getUserTypeName(data.type)}</td>

            <td className="d-flex py-1">
              <ButtonIcon onClick={() => handleEdit(data.id)}>
                <PencilFill className="text-black" />
              </ButtonIcon>
              <ButtonIcon>
                <XCircle className="text-danger mx-2" />
              </ButtonIcon>
            </td>
          </tr>
        ))}
      </Table>
      {userDetail && showDetail && (
        <Info user={userDetail} handleClose={handleCloseDetail} />
      )}
    </>
  );
};

export default UserTable;
