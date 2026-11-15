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
        TreeNode curr =root;
        while(_stack.Count>0 || curr!=null){
            while(curr!=null){
                _stack.Push(curr);
                curr=curr.left;
            }

            k--;
            curr = _stack.Pop();
            if(k==0) return curr.val;

            curr=curr.right;
        }
        
        return -1;
    }
  
}
