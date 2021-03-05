import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import axios from 'axios';

export const AddNote = () => {

    const [title, setTitle] = useState('');
    const [content, setContent] = useState('');
    const history = useHistory();

    const onSubmit = (e) => {
        e.preventDefault();

        axios.post('http://localhost:3000/notes', { title, content });

        history.push('/');
    }

    const onTitleChange = (e) => {
        setTitle(e.target.value);
    }

    const onContentChange = (e) => {
        setContent(e.target.value);
    }


    return (
        <div className="py-2">
            <Form onSubmit={onSubmit}>
                <FormGroup>
                    <Label>Title</Label>
                    <Input type="text" value={title} onChange={onTitleChange} name="title" placeholder="Title" required></Input>
                </FormGroup>
                <FormGroup>
                    <Label>Content</Label>
                    <Input type="text" value={content} onChange={onContentChange} name="content" placeholder="Content" required></Input>
                </FormGroup>
                <Button type="submit">Add to the list</Button>
                <Link to="/" className="btn btn-danger ml-2">Cancel</Link>
            </Form>
        </div>
    )
}