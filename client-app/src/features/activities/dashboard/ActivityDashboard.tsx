import React from "react";
import { Grid } from "semantic-ui-react";
import { Activity } from "../../../app/models/Activity";
import ActivityList from "./ActivityList";
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/ActivityForm";
interface Props {
  activities: Activity[];
  selectedActivity: Activity | undefined;
  //set the function parameter and return type
  selectActivity: (id: string) => void;
  cancelSelectActivity: () => void;
  editMode:boolean;
  openForm: (id:string) => void;
  closeForm: () => void;
  createOrEdit:(activit:Activity) => void;
  deleteActivity: (id: string) => void;
}

export default function ActivityDashboard({
  activities,
  selectedActivity,
  selectActivity,
  cancelSelectActivity,
  editMode,
  openForm,
  closeForm,
  createOrEdit,
  deleteActivity
}: Props) {
  return (
    <Grid>
      <Grid.Column width="10">
        <ActivityList activities={activities} selectActivity={selectActivity} deleteActivity = {deleteActivity}/>
      </Grid.Column>
      <Grid.Column width="6">
        {selectedActivity && !editMode &&
        <ActivityDetails 
        activity={selectedActivity}
        cancelSelectActivity={cancelSelectActivity}
        openForm={openForm}
        />}
        {editMode &&
        <ActivityForm closeForm={closeForm} activity={selectedActivity} createOrEdit={createOrEdit}/>}
      </Grid.Column>
    </Grid>
  );
}
