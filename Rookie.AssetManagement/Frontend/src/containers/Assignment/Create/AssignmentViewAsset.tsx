import { useField } from 'formik';
import React, {useState, useEffect, InputHTMLAttributes } from 'react'
import { Modal } from 'react-bootstrap';
import { Search } from 'react-feather';
import CustomTable from 'src/components/Table/CustomTable';
import { ACCSENDING, DECSENDING, DEFAULT_PAGE_LIMIT, DEFAULT_USER_SORT_COLUMN_NAME } from 'src/constants/paging';
import { getAssetCategories, getAssets } from 'src/containers/Asset/reducer';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IAsset from 'src/interfaces/Asset/IAsset';
import IQueryAssetModel from 'src/interfaces/Asset/IQueryAssetModel';
import IColumnOption from 'src/interfaces/IColumnOption';

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
  name: string;
  onShow: (values?: boolean) => void,
};

export const AssignmentViewAsset: React.FC<InputFieldProps> = (props) => {
  const [field, { value }, { setValue }] = useField(props);
  const { name, onShow } = props;
  
  const dispatch = useAppDispatch()
  const { assets } = useAppSelector((state) => state.assetReducer)

  const [query, setQuery] = useState({
    page: assets?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_USER_SORT_COLUMN_NAME
  } as IQueryAssetModel);    

  const columns: IColumnOption[] = [
    { columnName: "", columnValue: ""},
    { columnName: "Asset Code", columnValue: "code" },
    { columnName: "Asset Name", columnValue: "name" },
    { columnName: "Category", columnValue: "category" },
    ];

  const [search, setSearch] = useState("");
  const [selectAsset, setSelectAsset] = useState<IAsset>();

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

  const Save = () => {
    setValue(selectAsset);
    onShow(false);
  }

  const handleClose = () => {
    onShow(false);
    setSelectAsset(undefined);
  }
      
  const fetchData = () => {
    dispatch(getAssets(query));
    dispatch(getAssetCategories());
    setSelectAsset(undefined);
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
          Select Asset
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
            currentPage: assets?.currentPage,
            totalPage: assets?.totalPages,
            handleChange: handlePage,
          }}
        >
          {assets?.items.map((data, index) => (
            <tr
              key={index}
              className=""
            >
              <th scope="row" className="checkRow">
                <input
                    type="radio"
                    className=""
                    name="selectAsset"
                    checked = {value == data || selectAsset == data}
                    onChange={() => setSelectAsset(data)}
                />
              </th>
                <td className="py-1">{data.code}</td>
                <td className="py-1">{data.name} </td>
                <td className="py-1">{data.category.name}</td>
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
            disabled={!selectAsset}
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