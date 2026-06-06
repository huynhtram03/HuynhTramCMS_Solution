import React, { useEffect, useState } from "react";
import blogService from "../services/blogService";

const PostList = () => {

    const [posts, setPosts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const loadPosts = async () => {
            try {
                setLoading(true);

                const res = await blogService.getAllPosts();

                setPosts(res); // nếu backend trả array trực tiếp

            } catch (err) {
                console.error("Load posts error:", err);
            } finally {
                setLoading(false);
            }
        };

        loadPosts();
    }, []);

    // loading UI
    if (loading) {
        return <p className="text-center">Đang tải bài viết...</p>;
    }

    return (
        <div className="mt-4">

            <h4 className="mb-3 border-bottom pb-2">
                📰 Xu hướng & Bí quyết mặc đẹp
            </h4>

            {posts.length === 0 ? (
                <p>Chưa có bài viết nào</p>
            ) : (
                posts.map(post => (
                    <div key={post.id} className="card mb-3 shadow-sm">

                        <div className="card-body">

                            <h5>
                                <a href={`/post/${post.id}`}>
                                    {post.title}
                                </a>
                            </h5>

                            <p className="text-muted">
                                {post.shortDescription}
                            </p>

                            <small className="text-secondary">
                                📅 {new Date(post.createdDate).toLocaleDateString("vi-VN")}
                            </small>

                        </div>

                    </div>
                ))
            )}

        </div>
    );
};

export default PostList;