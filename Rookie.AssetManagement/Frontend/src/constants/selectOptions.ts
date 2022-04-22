import ISelectOption from "src/interfaces/ISelectOption";
import {
  StaffUserType,
  AdminUserType,
  AllUserType,
  StaffUserTypeLabel,
  AdminUserTypeLabel,
  AllUserTypeLabel,
} from "src/constants/User/UserConstants";
import {
  GenderMale,
  GenderFemale,
  GenderMaleLabel,
  GenderFemaleLabel,
} from "src/constants/User/GenderContants";
import {
    StateAvailable,
    StateNotAvailable,
    StateAvailableLabel,
    StateNotAvailableLabel,
} from "src/constants/Asset/StateConstants"

export const UserTypeOptions: ISelectOption[] = [
  { id: 1, label: AdminUserTypeLabel, value: AdminUserType },
  { id: 2, label: StaffUserTypeLabel, value: StaffUserType },
];

export const FilterUserTypeOptions: ISelectOption[] = [
  { id: 1, label: AllUserTypeLabel, value: AllUserType },
  { id: 2, label: AdminUserTypeLabel, value: AdminUserType },
  { id: 3, label: StaffUserTypeLabel, value: StaffUserType },
];

export const UserGenderOptions: ISelectOption[] = [
  { id: 1, label: GenderMaleLabel, value: GenderMale },
  { id: 2, label: GenderFemaleLabel, value: GenderFemale },
];

export const AssetStateOptions: ISelectOption[] = [
  { id: 1, label: "Available", value: 1 },
  { id: 2, label: "Not Available", value: 2 },
  { id: 3, label: "Assigned", value: 3 },
  { id: 4, label: "Waiting For Recycling", value: 4 },
  { id: 5, label: "Recycled", value: 5 },
];
export const AssignmentStateOptions: ISelectOption[] = [
  { id: 0, label: "All", value: 0 },
  { id: 1, label: "Waiting For Acceptance", value: 1 },
  { id: 2, label: "Accepted", value: 2 },
  // { id: 3, label: "Request For Returning", value: 3 },
  // { id: 4, label: "Returned", value: 4 },

];
export const AssetStateCreateOptions: ISelectOption[] = [
  { id: 1, label: StateAvailableLabel, value: StateAvailable },
  { id: 2, label: StateNotAvailableLabel, value: StateNotAvailable },
]
