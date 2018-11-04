import { BaseModel } from "./base";

export class JobRequirement extends BaseModel {
    courseId: number;
    courseName: string;
    userMeetRequirement: boolean;
}