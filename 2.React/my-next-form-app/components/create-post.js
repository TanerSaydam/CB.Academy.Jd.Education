import { createPost } from '@/lib/create-post';
import Form from 'next/form'

export default function CreatePost(){
    return (
        <>
          <Form action={createPost}>
            <input name="name" />
            <input name="title" />
            <button type="submit">Create Post</button>
          </Form>
        </>
      );
}