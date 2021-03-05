import React from 'react';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Home } from './components/Home';
import { Navigation } from './components/Navigation';
import { AddNote } from './components/AddNote';
import { EditNote } from './components/EditNote';
import { SingleNote } from './components/singleNote';

function App() {
  return (
    <Router>
      <Navigation />
      <div className="container">
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/add" component={AddNote} />
          <Route path="/edit/:id" component={EditNote} />
          <Route path="/note/:id" component={SingleNote} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;
