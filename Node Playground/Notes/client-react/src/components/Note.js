import React from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';
import { Button } from 'reactstrap';

export const Note = (props) => {

    const history = useHistory();

    const removeNote = () => {
        axios.delete(`http://localhost:3000/notes/${props._id}`);
        history.push('/');
    }

    return (
        <div>
            <h3> <Link to={'/note/' + props._id}>{props.title}</Link> </h3>
            <p>{props.content}</p>
            <div className="ml-auto">
                <Button onClick={removeNote} color="danger">Delete</Button>
            </div>
        </div>
    )
}