export const LOGIN = '/login';

export const HOME = '/home';

export const NOTFOUND = '/notfound';

export const MANAGE_USER = '/user';
export const CREATE_USER = '/user/createUser';
export const EDIT_USER = '/user/edit/:id';
export const EDIT_USER_ID = (id: string | number) => `/user/edit/${id}`;

export const MANAGE_ASSET = '/asset';
export const CREATE_ASSET = '/asset/createAsset';
export const EDIT_ASSET = '/asset/edit/:id';
export const EDIT_ASSET_ID = (id: string | number) => `/asset/edit/${id}`;

export const MANAGE_ASSIGNMENT = '/assignment';
export const CREATE_ASSIGNMENT = '/assignment/createAssignment';
export const EDIT_ASSIGNMENT = "/assignment/edit/:id";
export const EDIT_ASSIGNMENT_ID = (id: string | number) =>
	`/assignment/edit/${id}`;

export const REQUEST_FOR_RETURNING = '/returning'
export const REPORT= '/report';