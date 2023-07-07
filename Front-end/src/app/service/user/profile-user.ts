import { PostCard } from "../post/post-card";

export interface UserProfile{
    name : string,
    userName : string,
    userPhoto : string,
    userPhotoBackground : string,
    bornDate : Date,
    assignDate: Date,
    postList : PostCard[]
}