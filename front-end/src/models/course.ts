import { BaseModel } from "./base";
import { JobRequirement } from "./job-requirement";
import { Class } from "./class";

export class Course extends BaseModel {
    classes: Class[];
    description: string;
    expectedHours: number;
    id: number;
    imagePath: string;
    level: number;
    name: string;
    requiredCourseId: number;
    requiredCourseName: string;
    slug: string;
    usedUsedHours: number;
    userCompleted: boolean;
    userMeetRequirement: boolean;
    userProgression: number;

    static fromData(data) {
        let u = super.fromData(data);
        u.classes = u.classes.map(x => Class.fromData(x));
        return u;
    }
}
