import { BaseModel } from "./base";
import { JobRequirement } from "./job-requirement";

export class Job extends BaseModel {
    courseId: number;
    courseName: string;
    available: boolean;
    baseCode: string;
    completed: boolean;
    description: string;
    imagePath: string;
    reportedProgression: number;
    userMeetRequirement: boolean;
    title: string;

    usedHours: number;
    userDoingJob: boolean = false;
    userId: number;
    verificationCode: string;
    yourUserDoing: boolean;
    requirements: JobRequirement[];

    estimatedHours: number;
    id: number;
    slug: string

    static fromData(data) {
        let u = super.fromData(data);
        u.requirements = u.requirements.map(x => JobRequirement.fromData(x));
        return u;
    }
}

