import { useEffect, useState } from "react";
import axios from "axios";
import { List, ListItem, ListItemText } from "@mui/material";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios
      .get<Activity[]>("https://localhost:5001/api/activities")
      .then((response) => {
        setActivities(response.data);
        console.log(response.data);
      })
      .catch((err) => console.log(err));
  }, []);
  return (
    <>
      <h2 className="head-font">Postier</h2>

      <List>
        {activities?.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  );
}

export default App;
