/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> _stack = new();
        _stack.Push(root);
        while(_stack.Count>0){
            var node = _stack.Peek();
            if(node.left!=null){
                _stack.Push(node.left);
                node.left=null;
                continue;
            }
            k--;
            _stack.Pop();
            if(k==0) return node.val;
            if(node.right!=null){
                _stack.Push(node.right);
                node.right=null;
            }
        }
        return -1;
    }
  
}
