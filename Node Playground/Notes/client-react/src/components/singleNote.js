import React, { useState, useEffect } from 'react';
import { useHistory, useParams, Link } from 'react-router-dom';
import axios from 'axios';
import { Button, Card, CardTitle, CardText, Row, Col } from 'reactstrap';


export const SingleNote = (props) => {
    const [note, setNote] = useState({
        title: 'Untitled note',
        content: 'Random content',
        createdAt: null
    });

    const params = useParams();
    const history = useHistory();

    useEffect(() => {
        axios.get(`http://localhost:3000/notes/${params.id}`)
            .then(res => {
                setNote(res.data);
            })
    }, []);

    const removeNote = () => {
        axios.delete(`http://localhost:3000/notes/${props._id}`);
        history.push('/');
    }

    return (
        <div>
            <Card body>
                <CardTitle tag="h5">{note.title}</CardTitle>
                <CardText>
                    <small className="text-muted">{note.createdAt}</small>
                </CardText>
                <CardText>{note.content}</CardText>
                <Row>
                    <Col sm='6'>
                        <Link to={'/edit/' + note._id} className="w-100 btn btn-warning">Edit</Link>
                    </Col>
                    <Col sm='6'>
                        <Button color="danger" onClick={removeNote} className="w-100">Delete</Button>
                    </Col>
                </Row>
            </Card>
        </div>

    )
}