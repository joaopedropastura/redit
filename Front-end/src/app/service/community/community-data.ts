import { PostCard } from "../post/post-card"

export interface CommunityData{
    communityName : string 
    userNameOwner : string 
    inCommunity : boolean
    description : string
    members : number
    postList : PostCard[]
}