import { useEffect, useState } from "react";
import "./App.css";
import { List, ListItemText, Typography } from "@mui/material";
import axios from "axios";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>("https://localhost:5001/api/activities")
      .then(response => setActivities(response.data));
  }, []);

  const title = "Welcome to Reactivities";
  return (
    <>
      <Typography variant="h3">{title}</Typography>
      <List>
        {activities.map((activity) => (
          <ListItemText key={activity.id}>{activity.title}</ListItemText>
        ))}
      </List>
    </>
  );
}

export default App;
