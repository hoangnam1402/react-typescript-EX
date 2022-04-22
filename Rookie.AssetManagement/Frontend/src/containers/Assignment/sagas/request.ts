import { AxiosResponse } from "axios";
import qs from "qs";
import RequestService from "src/services/request";
import EndPoints from "src/constants/endpoints";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import IAsset from "src/interfaces/Asset/IAsset";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignment";
import IAssignmentRespond from "src/interfaces/Assignment/IAssignmentRespond";
import IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";

export function getAssignmentRequest(
  query: IQueryAssignmentModel
): Promise<AxiosResponse<IAssignment>> {
  return RequestService.axios.get(EndPoints.getAssignment, {
    params: query,
    paramsSerializer: (params) => qs.stringify(params),
  });
}

export function postCreateAssignment(assignment: IAssignmentForm): Promise<AxiosResponse<IAssignmentForm>> {
    return RequestService.axios.post(EndPoints.createAssignment, assignment)
}

export function deleteAssignmentRequest(assignmentId: number): Promise<AxiosResponse<IAssignmentForm>> {
    return RequestService.axios.delete(EndPoints.deleteAssignmentId(assignmentId ?? -1))
}
export function putAssignmentsRequest(assignmentForm: IAssignmentForm): Promise<AxiosResponse<IAssignment>> {
	return RequestService.axios.put(
		EndPoints.getAssignmentId(assignmentForm.id ?? -1),
		assignmentForm,
		{
			paramsSerializer: (params) => qs.stringify(params),
		},
	);
}