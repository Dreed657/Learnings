import React from 'react';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Home } from './components/Home';
import { Navigation } from './components/Navigation';
import { AddNote } from './components/AddNote';
import { EditNote } from './components/EditNote';
import { SingleNote } from './components/singleNote';

function App() {
  return (
    <div style={{ maxWidth: "30rem", margin: "0px auto" }}>
      <Router>
        <Navigation/>
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/add" component={AddNote} />
          <Route path="/edit/:id" component={EditNote} />
          <Route path="/note/:id" component={SingleNote} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
