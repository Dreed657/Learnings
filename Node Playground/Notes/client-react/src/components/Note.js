import React from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';
import { Button } from 'reactstrap';
import { BiTrash, BiEditAlt } from 'react-icons/bi';

export const Note = (props) => {

    const history = useHistory();

    const removeNote = () => {
        axios.delete(`http://localhost:3000/notes/${props._id}`);
        history.push('/');
    }

    return (
        <div className="my-2 border p-2">
            <div className="row">
                <div className="col">
                    <h3> <Link to={'/note/' + props._id}>{props.title}</Link> </h3>
                    <p>{props.content}</p>
                </div>
                <div className="col-auto">
                    <div className="my-2">
                        <Link to={'/edit/' + props._id}> <Button color="warning mr-2"> <BiEditAlt /> </Button> </Link>
                        <Button onClick={removeNote} color="danger"> <BiTrash /> </Button>
                    </div>
                </div>
            </div>
        </div>
    )
}